<template>
  <nm-list-dialog v-bind="dialogOptions" :visible.sync="visible_" @open="onOpen">
    <nm-list ref="list" v-bind="list" @reset="onReset">
      <template v-slot:querybar>
        <el-form-item label="名称：" prop="name">
          <el-input v-model="list.model.name" clearable />
        </el-form-item>
      </template>

      <template v-slot:querybar-buttons>
        <nm-button type="success" text="添加" icon="add" @click="add" />
      </template>

      <template v-slot:menuIcon="{ row }">
        <nm-icon :name="row.menuIcon" />
      </template>

      <template v-slot:col-operation="{ row }">
        <nm-button text="属性管理" icon="entity" type="text" @click="manageProperty(row)" />
        <nm-button text="视图模型" icon="entity" type="text" @click="openModelManage(row)" />
        <nm-button text="生成代码" icon="download" type="text" @click="buildCode(row)" />
        <!-- <nm-button text="预览代码" icon="display" type="text" @click="codePreview(row)" /> -->
        <nm-button text="编辑" icon="edit" type="text" @click="edit(row)" />
        <nm-button-delete :action="removeAction" :id="row.id" @success="refresh" />
      </template>
    </nm-list>

    <save-page :id="curr.id" :module="module" :visible.sync="dialog.save" @success="refresh" />
    <property-page :parent="curr" :visible.sync="dialog.property" />
    <model-manage-page :parent="curr" :visible.sync="dialog.model" />
    <code-preview :id="curr.id" :visible.sync="dialog.codePreview" />
  </nm-list-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'
import cols from './cols.js'
import SavePage from '../components/save'
import PropertyPage from '../../property/index'
import ModelManagePage from '../../modelProperty/index'
import CodePreview from '../components/code-preview'

const api = $api.codeGenerator.class

export default {
  mixins: [mixins.visible, mixins.list],
  components: { SavePage, PropertyPage, ModelManagePage, CodePreview },
  data() {
    return {
      curr: { name: '' },
      list: {
        noHeader: true,
        queryOnCreated: false,
        action: api.query,
        operationWidth: '400',
        model: {
          moduleId: '',
          name: ''
        },
        cols
      },
      dialog: {
        property: false,
        model: false,
        codePreview: false
      },
      removeAction: api.remove
    }
  },
  props: {
    module: {
      type: Object,
      required: true
    }
  },
  computed: {
    dialogOptions() {
      return {
        title: `实体列表(${this.module.name})`,
        icon: 'list',
        width: '80%'
      }
    }
  },
  methods: {
    /** 打开模型管理 */
    openModelManage(row) {
      this.curr.id = row.id
      this.curr.name = row.name
      this.dialog.model = true
    },
    manageProperty(row) {
      this.curr.id = row.id
      this.curr.name = row.name
      this.dialog.property = true
    },
    buildCode(row) {
      this._openLoading('正在努力生成代码，请稍后...')
      api
        .buildCode(row.id)
        .then(() => {
          this._closeLoading()
        })
        .catch(() => {
          this._closeLoading()
        })
    },
    codePreview(row) {
      this.curr.id = row.id
      this.curr.name = row.name
      this.dialog.codePreview = true
    },
    onOpen() {
      this.$nextTick(() => {
        this.$refs.list.reset()
      })
    },
    onReset() {
      this.list.model.moduleId = this.module.id
      this.$refs.list.query()
    }
  }
}
</script>
