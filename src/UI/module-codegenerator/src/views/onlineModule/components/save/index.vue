<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="名称：" prop="name">
          <el-input v-model="form.model.name" clearable />
        </el-form-item>
        <el-form-item label="编码：" prop="code">
          <el-input v-model="form.model.code" clearable />
        </el-form-item>
        <el-form-item label="图标：" prop="icon">
          <el-input v-model="form.model.icon" clearable />
        </el-form-item>
        <el-form-item label="介绍说明：" prop="description">
          <el-input v-model="form.model.description" clearable />
        </el-form-item>
        <el-form-item label="NuGet包ID：" prop="nuGetId">
          <el-input v-model="form.model.nuGetId" clearable />
        </el-form-item>
        <el-form-item label="NPM包ID：" prop="npmId">
          <el-input v-model="form.model.npmId" clearable />
        </el-form-item>
        <el-form-item label="公司名称：" prop="company">
          <el-input v-model="form.model.company" clearable />
        </el-form-item>
        <el-form-item label="项目地址：" prop="projectUrl">
          <el-input v-model="form.model.projectUrl" clearable />
        </el-form-item>
        <el-form-item label="仓库地址：" prop="repositoryUrl">
          <el-input v-model="form.model.repositoryUrl" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { add, edit, update } = $api.codeGenerator.onlineModule

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '在线模块',
      actions: { add, edit, update },
      form: {
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
        },
        rules: {}
      }
    }
  }
}
</script>
