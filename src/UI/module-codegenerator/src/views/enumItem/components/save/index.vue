<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="所属枚举：">
          <el-input :value="`${parent.remarks}(${parent.name})`" disabled />
        </el-form-item>
        <el-form-item label="名称：" prop="name">
          <el-input ref="name" v-model="form.model.name" />
        </el-form-item>
        <el-form-item label="值：" prop="value">
          <el-input v-model.number="form.model.value" />
        </el-form-item>
        <el-form-item label="备注：" prop="remarks">
          <el-input v-model="form.model.remarks" />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { add, edit, update } = $api.codeGenerator.enumItem

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '枚举项',
      actions: { add, edit, update },
      form: {
        width: '40%',
        model: {
          enumId: '',
          name: '',
          value: '',
          remarks: ''
        },
        rules: {
          name: [{ required: true, message: '请输入名称', trigger: 'blur' }],
          value: [
            { required: true, message: '请输入值', trigger: 'blur' },
            { type: 'number', message: '请输入正确的数值', trigger: 'blur' }
          ],
          remarks: [{ required: true, message: '请输入备注', trigger: 'blur' }]
        }
      },
      on: {
        reset: this.onReset
      }
    }
  },
  props: {
    parent: {
      type: Object,
      required: true
    }
  },
  methods: {
    onReset() {
      this.form.model.enumId = this.parent.id
      this.$refs.name.focus()
    }
  }
}
</script>
