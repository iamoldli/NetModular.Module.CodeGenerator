﻿using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.CodeGenerator.Domain.Class;

namespace NetModular.Module.CodeGenerator.Application.ClassService.ViewModels
{
    public class ClassAddModel
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        public Guid ModuleId { get; set; }

        /// <summary>
        /// 类名称
        /// </summary>
        [Required(ErrorMessage = "请输入名称")]
        public string Name { get; set; }

        /// <summary>
        /// 表名称
        /// </summary>
        [Required(ErrorMessage = "请输入表名")]
        public string TableName { get; set; }

        /// <summary>
        /// 基类类型
        /// </summary>
        public BaseEntityType BaseEntityType { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [Required(ErrorMessage = "请输入类名")]
        public string Remarks { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string MenuIcon { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public ClassMethodModel Method { get; set; }
    }
}
