<template>
  <nm-form-page v-bind="form">
    <el-row :gutter="20">
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
      <el-col :span="20" :offset="1">
        <el-form-item label="生成代码存储路径：" prop="buildCodePath">
          <el-input v-model="form.model.buildCodePath" placeholder="默认保存在通用临时路径下的CodeGenerator\BuildCode目录下" />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-page>
</template>
<script>
import { mixins } from 'netmodular-module-admin'
import module from '../../module'
export default {
  mixins: [mixins.configForm],
  data() {
    return {
      code: module.code,
      form: {
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
  }
}
</script>
