const isDev = process.env.NODE_ENV !== 'production'

const config = {
  baseUrl: '/api/'
}

// 开发模式
if (isDev) {
  config.baseUrl = 'https://api.demo.17mkh.com/api/'
}
export default config
