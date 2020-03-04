<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="名称：" prop="name">
          <el-input ref="name" v-model="form.model.name" />
        </el-form-item>
        <el-form-item label="编号：" prop="no">
          <el-input v-model.number="form.model.no" />
          <nm-txt type="warning"> 当前项目启动端口号为：后端{{ 6220 + form.model.no }}，后端{{ 5220 + form.model.no }} </nm-txt>
        </el-form-item>
        <el-form-item label="编码：" prop="code">
          <el-input v-model="form.model.code" />
        </el-form-item>
        <el-form-item label="图标：" prop="icon">
          <nm-icon-picker v-model="form.model.icon" />
        </el-form-item>
        <el-form-item label="版权声明：" prop="copyright">
          <el-input v-model="form.model.copyright" clearable />
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

const { add, edit, update } = $api.codeGenerator.module

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '模块',
      actions: { add, edit, update },
      form: {
        width: '30%',
        labelWidth: '120px',
        model: {
          name: '',
          no: 0,
          code: '',
          icon: '',
          copyright: '',
          company: '',
          projectUrl: '',
          repositoryUrl: ''
        },
        rules: {
          name: [{ required: true, message: '请输入名称', trigger: 'blur' }],
          code: [{ required: true, message: '请输入编码', trigger: 'blur' }],
          no: [
            { required: true, message: '请输入编号', trigger: 'blur' },
            { type: 'number', min: 0, max: 59315, message: '编码在 0 到 59315 之间', trigger: 'blur' }
          ],
          icon: [{ required: true, message: '请选择图标', trigger: 'blur' }],
          copyright: [{ required: true, message: '请输入版权声明', trigger: 'blur' }],
          projectUrl: [{ type: 'url', message: '请输入有效的URL', trigger: 'blur' }],
          repositoryUrl: [{ type: 'url', message: '请输入有效的URL', trigger: 'blur' }]
        }
      },
      on: {
        reset: this.onReset
      }
    }
  },
  methods: {
    onReset() {
      this.$refs.name.focus()
    }
  }
}
</script>
