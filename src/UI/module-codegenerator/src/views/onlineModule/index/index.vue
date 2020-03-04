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
        <el-form-item label="图标：" prop="icon">
          <el-input v-model="list.model.icon" clearable />
        </el-form-item>
        <el-form-item label="介绍说明：" prop="description">
          <el-input v-model="list.model.description" clearable />
        </el-form-item>
        <el-form-item label="NuGet包ID：" prop="nuGetId">
          <el-input v-model="list.model.nuGetId" clearable />
        </el-form-item>
        <el-form-item label="NPM包ID：" prop="npmId">
          <el-input v-model="list.model.npmId" clearable />
        </el-form-item>
        <el-form-item label="公司名称：" prop="company">
          <el-input v-model="list.model.company" clearable />
        </el-form-item>
        <el-form-item label="项目地址：" prop="projectUrl">
          <el-input v-model="list.model.projectUrl" clearable />
        </el-form-item>
        <el-form-item label="仓库地址：" prop="repositoryUrl">
          <el-input v-model="list.model.repositoryUrl" clearable />
        </el-form-item>
      </template>

      <!--按钮-->
      <template v-slot:querybar-buttons>
        <nm-button-has :options="buttons.add" @click="add" />
      </template>

      <!--自定义列-->
      <!-- <template v-slot:col-name="{row}">
        <nm-button :text="row.name" type="text" />
      </template> -->

      <!--操作列-->
      <template v-slot:col-operation="{ row }">
        <nm-button v-bind="buttons.edit" @click="edit(row)" />
        <nm-button-delete v-bind="buttons.del" :id="row.id" :action="removeAction" @success="refresh" />
      </template>
    </nm-list>

    <save-page :id="curr.id" :visible.sync="dialog.save" @success="refresh" />
  </nm-container>
</template>
<script>
import { mixins } from 'netmodular-ui'
import page from './page'
import cols from './cols'
import SavePage from '../components/save'

const api = $api.codeGenerator.onlineModule

export default {
  name: page.name,
  mixins: [mixins.list],
  components: { SavePage },
  data() {
    return {
      list: {
        title: page.title,
        cols,
        action: api.query,
        model: {
          /** 名称 */
          name: '',
          /** 编码 */
          code: '',
          /** 图标 */
          icon: '',
          /** 介绍说明 */
          description: '',
          /** NuGet包ID */
          nuGetId: '',
          /** NPM包ID */
          npmId: '',
          /** 公司名称 */
          company: '',
          /** 项目地址 */
          projectUrl: '',
          /** 仓库地址 */
          repositoryUrl: ''
        }
      },
      removeAction: api.remove,
      buttons: page.buttons
    }
  }
}
</script>
