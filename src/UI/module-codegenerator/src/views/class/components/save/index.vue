<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="所属项目：">
          <el-input v-model="module.name" disabled />
        </el-form-item>
        <el-form-item label="基类类型：" prop="baseEntityType">
          <nm-select :disabled="isEdit_" :method="getBaseEntityTypeSelect" v-model="form.model.baseEntityType" />
        </el-form-item>
        <el-form-item label="实体名称：" prop="name">
          <el-input ref="name" v-model="form.model.name" clearable />
        </el-form-item>
        <el-form-item label="表名：" prop="tableName">
          <el-input v-model="form.model.tableName" clearable />
        </el-form-item>
        <el-form-item label="备注：" prop="remarks">
          <el-input v-model="form.model.remarks" clearable placeholder="实体对应菜单名称采用该字段" />
        </el-form-item>
        <el-form-item label="菜单图标：" prop="menuIcon">
          <nm-icon-picker v-model="form.model.menuIcon" />
        </el-form-item>
        <el-form-item label="基础方法：" prop="method">
          <el-checkbox v-model="form.model.method.add">Add</el-checkbox>
          <el-checkbox v-model="form.model.method.delete">Delete</el-checkbox>
          <el-checkbox v-model="form.model.method.edit">Edit</el-checkbox>
          <el-checkbox v-model="form.model.method.query">Query</el-checkbox>
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { add, edit, update, getBaseEntityTypeSelect } = $api.codeGenerator.class

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '实体',
      actions: {
        add,
        edit,
        update
      },
      form: {
        width: '40%',
        model: {
          moduleId: '',
          name: '',
          tableName: '',
          baseEntityType: 7,
          remarks: '',
          menuIcon: '',
          method: {
            query: true,
            add: true,
            delete: true,
            edit: true
          }
        },
        rules: {
          moduleId: [{ required: true, message: '请选择项目', trigger: 'blur' }],
          name: [{ required: true, message: '请输入实体名称', trigger: 'blur' }],
          remarks: [{ required: true, message: '请输入备注', trigger: 'blur' }],
          tableName: [{ required: true, message: '请输入表名', trigger: 'blur' }]
        }
      },
      on: {
        reset: this.onReset
      }
    }
  },
  props: {
    module: {
      type: Object,
      required: true
    }
  },
  methods: {
    getBaseEntityTypeSelect() {
      return getBaseEntityTypeSelect()
    },
    onReset() {
      this.form.model.moduleId = this.module.id
      this.$refs.name.focus()
    }
  }
}
</script>
