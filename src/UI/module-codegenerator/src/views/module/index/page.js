/** 页面信息 */
const page = new (function() {
  this.title = '模块列表'
  this.icon = 'product'
  this.name = 'codegenerator_module'
  this.path = '/codegenerator/module'

  // 关联权限
  this.permissions = [`${this.name}_query_get`]

  // 按钮
  this.buttons = {
    add: {
      text: '添加',
      type: 'success',
      icon: 'add',
      code: `${this.name}_add`,
      permissions: [`${this.name}_add_post`]
    },
    edit: {
      text: '编辑',
      type: 'text',
      icon: 'edit',
      code: `${this.name}_edit`,
      permissions: [`${this.name}_edit_get`, `${this.name}_update_post`]
    },
    del: {
      text: '删除',
      type: 'text',
      icon: 'delete',
      code: `${this.name}_del`,
      permissions: [`${this.name}_delete_delete`]
    },
    buildCode: {
      text: '生成代码',
      type: 'text',
      icon: 'download',
      code: `${this.name}_build_code`,
      permissions: [`${this.name}_buildcode_post`]
    },
    classManage: {
      text: '实体管理',
      type: 'text',
      icon: 'database',
      code: `${this.name}_class_manage`,
      permissions: []
    }
  }
})()

/** 路由信息 */
export const route = {
  page,
  component: () => import(/* webpackChunkName: "codegenerator.module" */ './index')
}

export default page
