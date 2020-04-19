<template>
  <nm-container>
    <nm-list ref="list" v-bind="list">
      <!--查询条件-->
      <template v-slot:querybar>
        <el-form-item label="名称：" prop="name">
          <el-input v-model="list.model.name" clearable />
        </el-form-item>
        <el-form-item label="编码：" prop="code">
          <el-input v-model="list.model.code" clearable />
        </el-form-item>
      </template>

      <!--按钮-->
      <template v-slot:querybar-buttons>
        <nm-button v-bind="buttons.add" @click="add" />
      </template>

      <!--是否显示-->
      <template v-slot:col-isShow="{ row }">{{ row.isShow ? '是' : '否' }}</template>

      <template v-slot:col-icon="{ row }">
        <nm-icon :name="row.icon" class="nm-size-20" />
      </template>

      <template v-slot:col-projectUrl="{ row }">
        <el-link v-if="row.projectUrl" type="primary" :href="row.projectUrl" target="_blank">{{ row.projectUrl }}</el-link>
      </template>

      <template v-slot:col-repositoryUrl="{ row }">
        <el-link v-if="row.repositoryUrl" type="primary" :href="row.repositoryUrl" target="_blank">{{ row.repositoryUrl }}</el-link>
      </template>

      <!--操作列-->
      <template v-slot:col-operation="{ row }">
        <el-dropdown>
          <span class="el-dropdown-link"> 操作<i class="el-icon-arrow-down el-icon--right"></i> </span>
          <el-dropdown-menu slot="dropdown">
            <el-dropdown-item>
              <nm-button v-bind="buttons.classManage" @click="manageClass(row)" />
            </el-dropdown-item>
            <el-dropdown-item>
              <nm-button v-bind="buttons.buildCode" @click="buildCode(row)" />
            </el-dropdown-item>
            <el-dropdown-item>
              <nm-button v-bind="buttons.edit" @click="edit(row)" />
            </el-dropdown-item>
            <el-dropdown-item>
              <nm-button-delete v-bind="buttons.del" :action="removeAction" :id="row.id" @success="refresh" />
            </el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>
      </template>
    </nm-list>

    <save-page :id="curr.id" :visible.sync="dialog.save" @success="refresh" />
    <!--类管理-->
    <class-page :module="curr" :visible.sync="dialog.class" />
  </nm-container>
</template>
<script>
import { mixins } from 'netmodular-ui'
import page from './page'
import cols from './cols'
import SavePage from '../components/save'
import ClassPage from '../../class/index'

const api = $api.codeGenerator.module

export default {
  name: page.name,
  mixins: [mixins.list],
  components: { SavePage, ClassPage },
  data() {
    return {
      curr: { name: '' },
      list: {
        title: page.title,
        cols,
        action: api.query,
        model: {
          name: '',
          code: ''
        }
      },
      removeAction: api.remove,
      buttons: page.buttons,
      dialog: {
        class: false
      }
    }
  },
  methods: {
    buildCode(row) {
      this._openLoading('正在努力生成代码，首次生成需要调用官方NuGet接口查询最新包版本号，该过程较耗时，请您耐心等待...')
      api
        .buildCode({ id: row.id })
        .then(() => {
          this._closeLoading()
        })
        .catch(() => {
          this._closeLoading()
        })
    },
    manageClass(row) {
      this.curr.id = row.id
      this.curr.name = row.name
      this.dialog.class = true
    }
  }
}
</script>
