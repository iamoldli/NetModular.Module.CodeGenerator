/** 页面信息 */
const page = new (function() {
  this.title = '枚举列表'
  this.icon = 'tag'
  this.name = 'codegenerator_enum'
  this.path = '/codegenerator/enum'
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
    item: {
      text: '配置项',
      type: 'text',
      icon: 'tag',
      code: `${this.name}_item`
    }
  }
})()

/** 路由信息 */
export const route = {
  page,
  component: () => import(/* webpackChunkName: "admin.moduleinfo" */ './index')
}

export default page
