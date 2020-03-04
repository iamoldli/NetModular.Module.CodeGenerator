import { mixins } from 'netmodular-ui'
export default {
  mixins: [mixins.select],
  data() {
    return {
      action: $api.codeGenerator.enum.select
    }
  }
}
