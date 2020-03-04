<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="名称：" prop="name">
          <el-input ref="name" v-model="form.model.name" />
        </el-form-item>
        <el-form-item label="备注：" prop="remarks">
          <el-input v-model="form.model.remarks" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { add, edit, update } = $api.codeGenerator.enum

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '枚举',
      actions: { add, edit, update },
      form: {
        width: '400px',
        labelWidth: '70px',
        model: {
          name: '',
          remarks: ''
        },
        rules: {
          name: [{ required: true, message: '请输入名称', trigger: 'blur' }],
          remarks: [{ required: true, message: '请输入备注', trigger: 'blur' }]
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
