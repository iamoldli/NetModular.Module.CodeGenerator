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

      <!--操作列-->
      <template v-slot:col-operation="{ row }">
        <nm-button v-bind="buttons.item" @click="manageItem(row)" />
        <nm-button v-bind="buttons.edit" @click="edit(row)" />
        <nm-button-delete v-bind="buttons.del" :action="removeAction" :id="row.id" @success="refresh" />
      </template>
    </nm-list>

    <save-page :id="curr.id" :visible.sync="dialog.save" @success="refresh" />
    <!--项管理-->
    <item-page :parent="curr" :visible.sync="dialog.item" />
  </nm-container>
</template>
<script>
import { mixins } from 'netmodular-ui'
import page from './page'
import cols from './cols'
import SavePage from '../components/save'
import ItemPage from '../../enumItem/index'

const api = $api.codeGenerator.enum

export default {
  name: page.name,
  mixins: [mixins.list],
  components: { SavePage, ItemPage },
  data() {
    return {
      list: {
        title: page.title,
        cols,
        action: api.query,
        model: {
          name: ''
        }
      },
      removeAction: api.remove,
      buttons: page.buttons,
      dialog: {
        item: false
      }
    }
  },
  methods: {
    manageItem(row) {
      this.curr.id = row.id
      this.curr.name = row.name
      this.dialog.item = true
    }
  }
}
</script>
