import axios from "axios";
import constanturl from "@/common/constant.url";

axios.defaults.withCredentials = true;
axios.defaults.crossDomain = true;

export default {
  login(data, callback, errorcallback) {
    axios
      .post(constanturl.LOGIN_URL, {
        Username: data.username,
        Password: data.password
      })
      .then(function(response) {
        callback(response);
      })
      .catch(function(error) {
        errorcallback(error);
      });
  }
};
