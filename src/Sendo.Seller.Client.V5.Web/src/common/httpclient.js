import axios from 'axios'
import constant from '../constant'
import constanturl from '../constant.url'

var sellerApi = axios.create({
  baseURL: constanturl.API_URL,
  timeout: constanturl.TIMEOUT_HTTP,
  headers: {'Authorization': constant.authorization_type + ' ' + localStorage.getItem(constant.localStorage_token)}
})

export default {
  sellerApi
}
