import WebHost from 'netmodular-module-admin'
import config from './config'
import CodeGenerator from './index'

// 注入模块
WebHost.registerModule(CodeGenerator)

// 启动
WebHost.start(config)
