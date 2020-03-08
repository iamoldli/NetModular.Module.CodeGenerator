<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="所属实体：">
          <el-input :value="`${parent.remarks}(${parent.name})`" disabled />
        </el-form-item>
        <el-form-item label="名称：" prop="name">
          <el-input ref="name" v-model="form.model.name" />
        </el-form-item>
        <el-form-item label="类型：" prop="type">
          <type-select v-model="form.model.type" />
        </el-form-item>
        <el-form-item v-show="showLength" prop="length">
          <template v-slot:label>
            <el-tooltip effect="dark" content="0标识最大长度，比如SqlServer就是nvarchar(MAX)" placement="top"> <nm-icon name="question" class="nm-size-20 nm-text-warning"/></el-tooltip> 长度</template
          >
          <el-input v-model.number="form.model.length" />
        </el-form-item>
        <el-form-item v-show="showPrecision" label="精度：" prop="precision">
          <el-input v-model.number="form.model.precision" />
        </el-form-item>
        <el-form-item v-show="showScale" label="刻度：" prop="scale">
          <el-input v-model.number="form.model.scale" />
        </el-form-item>
        <el-form-item v-show="showEnum" label="枚举：" prop="enumId">
          <enum-select v-model="form.model.enumId" />
        </el-form-item>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="6" :offset="1">
        <el-form-item label="可空：" prop="nullable">
          <el-switch v-model="form.model.nullable" />
        </el-form-item>
      </el-col>
      <el-col :span="7">
        <el-form-item label="列表显示：" prop="showInList">
          <el-switch v-model="form.model.showInList" />
        </el-form-item>
      </el-col>
      <el-col :span="6">
        <el-form-item label="包含默认值：" prop="hasDefaultValue">
          <el-switch v-model="form.model.hasDefaultValue" />
        </el-form-item>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="备注：" prop="remarks">
          <el-input v-model="form.model.remarks" />
        </el-form-item>
        <el-form-item label="序号：" prop="sort">
          <el-input type="number" v-model.number="form.model.sort" />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'
import TypeSelect from '../type-select'
import EnumSelect from '../../../enum/components/select'

const { add, edit, update } = $api.codeGenerator.property
const enumApi = $api.codeGenerator.enum

export default {
  mixins: [mixins.formSave],
  components: { TypeSelect, EnumSelect },
  data() {
    // 验证字符串长度
    const validateLength = (rule, value, callback) => {
      if (this.showLength) {
        if (value === '') {
          callback(new Error('请输入长度'))
        } else if (!Number.isInteger(value)) {
          callback(new Error('请输入正确的长度'))
        } else if (value < 0) {
          callback(new Error('长度不能小于0'))
        } else {
          callback()
        }
      } else {
        callback()
      }
    }

    // 验证精度
    const validatePrecision = (rule, value, callback) => {
      if (this.showPrecision) {
        if (value === '') {
          callback(new Error('请输入精度'))
        } else if (!Number.isInteger(value)) {
          callback(new Error('请输入正确的精度'))
        } else if (value < 1) {
          callback(new Error('精度不能小于1'))
        } else {
          callback()
        }
      } else {
        callback()
      }
    }

    // 验证刻度
    const validateScale = (rule, value, callback) => {
      if (this.showScale) {
        if (value === '') {
          callback(new Error('请输入刻度'))
        } else if (!Number.isInteger(value)) {
          callback(new Error('请输入正确的刻度'))
        } else if (value < 0) {
          callback(new Error('刻度不能小于0'))
        } else if (value > this.form.model.precision) {
          callback(new Error('刻度不能大于精度'))
        } else {
          callback()
        }
      } else {
        callback()
      }
    }

    // 验证枚举
    const validateEnum = (rule, value, callback) => {
      if (this.showEnum && value === '') {
        callback(new Error('请选择枚举'))
      } else {
        callback()
      }
    }

    return {
      title: '属性',
      actions: {
        add,
        edit,
        update
      },
      form: {
        width: '40%',
        model: {
          classId: 0,
          name: '',
          type: 0,
          length: 50,
          precision: 0,
          scale: 0,
          enumId: '',
          nullable: false,
          remarks: '',
          sort: 0,
          showInList: true,
          hasDefaultValue: false
        },
        rules: {
          classId: [{ required: true, message: '请选择类', trigger: 'blur' }],
          name: [{ required: true, message: '请输入类名', trigger: 'blur' }],
          type: [
            { required: true, message: '请选择类型', trigger: 'blur' },
            { type: 'number', message: '请选择正确的类型', trigger: 'blur' }
          ],
          length: [{ validator: validateLength }],
          precision: [{ validator: validatePrecision }],
          scale: [{ validator: validateScale }],
          enumId: [{ validator: validateEnum }],
          remarks: [{ required: true, message: '请输入备注', trigger: 'blur' }]
        }
      },
      on: {
        success: this.onSuccess,
        open: this.onOpen,
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
  computed: {
    showLength() {
      return this.form.model.type === 0
    },
    showPrecision() {
      return this.form.model.type === 5 || this.form.model.type === 6
    },
    showScale() {
      return this.form.model.type === 6
    },
    showEnum() {
      return this.form.model.type === 10
    }
  },
  methods: {
    getEnumSelect() {
      return enumApi.select()
    },
    onReset() {
      this.form.model.classId = this.parent.id
      this.form.model.sort = this.total
      this.$refs.name.focus()
    }
  },
  watch: {
    'form.model.type'() {
      if (!this.showLength) {
        this.form.model.length = 0
      }
      if (!this.showPrecision) {
        this.form.model.precision = 0
        this.form.model.scale = 0
      }
      if (!this.showEnum) {
        this.form.model.enumId = ''
      }
    }
  }
}
</script>
