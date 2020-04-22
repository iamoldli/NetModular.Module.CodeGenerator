<template>
  <nm-form-page v-bind="form">
    <el-row>
      <el-col :span="10" :offset="1">
        <el-form-item label="模块前缀(后端命名空间)：" prop="prefix">
          <el-input v-model="form.model.prefix" />
        </el-form-item>
      </el-col>
      <el-col :span="10">
        <el-form-item label="前端组件前缀：" prop="uiPrefix">
          <el-input v-model="form.model.uiPrefix" />
        </el-form-item>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="生成代码存储路径：" prop="buildCodePath">
          <el-input v-model="form.model.buildCodePath" placeholder="默认保存在通用临时路径下的CodeGenerator\BuildCode目录下" />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-page>
</template>
<script>
import module from '../../module'
const { edit, update } = $api.admin.config
export default {
  data() {
    return {
      code: module.code,
      type: 1,
      form: {
        header: false,
        action: this.update,
        labelWidth: '200px',
        model: {
          prefix: '',
          uiPrefix: '',
          buildCodePath: ''
        },
        rules: {
          prefix: [{ required: true, message: '模块前缀不能为空' }],
          uiPrefix: [{ required: true, message: '前端组件前缀不能为空' }]
        }
      }
    }
  },
  methods: {
    update() {
      return update({ type: this.type, code: this.code, json: JSON.stringify(this.form.model) })
    }
  },
  created() {
    edit({ type: this.type, code: this.code }).then(data => {
      this.form.model = data
    })
  }
}
</script>
