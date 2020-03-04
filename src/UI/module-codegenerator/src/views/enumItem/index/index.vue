<template>
  <nm-list-dialog :title="`枚举项列表(${parent.name})`" icon="list" height="80%" :visible.sync="visible_" @open="onOpen">
    <nm-list ref="list" v-bind="list">
      <template v-slot:querybar>
        <el-form-item label="名称：" prop="name">
          <el-input v-model="list.model.name" clearable />
        </el-form-item>
      </template>

      <template v-slot:querybar-buttons>
        <nm-button type="success" text="添加" icon="add" @click="add" />
        <nm-button type="warning" text="排序" icon="sort" @click="openSort" />
      </template>

      <template v-slot:col-operation="{ row }">
        <nm-button text="编辑" icon="edit" type="text" @click="edit(row)" />
        <nm-button-delete :action="removeAction" :id="row.id" @success="refresh" />
      </template>
    </nm-list>

    <save-page :id="curr.id" :parent="parent" :visible.sync="dialog.save" @success="refresh" />
    <nm-drag-sort-dialog v-bind="dragSort" :visible.sync="dialog.sort" @success="refresh" />
  </nm-list-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'
import cols from './cols.js'
import SavePage from '../components/save'

const api = $api.codeGenerator.enumItem

export default {
  mixins: [mixins.list, mixins.visible],
  components: { SavePage },
  data() {
    return {
      list: {
        noHeader: true,
        queryOnCreated: false,
        action: api.query,
        model: {
          enumId: '',
          name: ''
        },
        cols
      },
      dialog: {
        sort: false
      },
      removeAction: api.remove
    }
  },
  props: {
    parent: {
      type: Object,
      required: true
    }
  },
  computed: {
    dragSort() {
      return {
        queryAction: this.querySortList,
        updateAction: api.updateSortList
      }
    }
  },
  methods: {
    openSort() {
      this.dialog.sort = true
    },
    querySortList() {
      return api.querySortList(this.parent.id)
    },
    onOpen() {
      this.$nextTick(() => {
        this.$refs.list.reset()
        this.list.model.enumId = this.parent.id
        this.$refs.list.query()
      })
    }
  }
}
</script>
