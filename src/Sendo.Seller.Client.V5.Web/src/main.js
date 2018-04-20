// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from "vue";
import Vuex from "vuex";
// import App from './App'
import store from "./store";
import router from "./router";
import Vuetify from "vuetify";
import { VueExtendLayout, layout } from "vue-extend-layout";

import VueMoment from "vue-moment";
import moment from "moment-timezone";

import axios from "axios";

import "vuetify/dist/vuetify.min.css"; // Ensure you are using css-loader

require("moment/locale/vi");

Vue.config.productionTip = false;
Vue.use(Vuex);
Vue.use(Vuetify);
Vue.use(VueExtendLayout);

// https://github.com/brockpetrie/vue-moment
Vue.use(VueMoment, {
  moment
});

console.log(Vue.moment().locale()); // vi

router.beforeEach((to, from, next) => {
  console.log(
    "router.beforeEach store.state.authen.isLoggedIn",
    store.state.authen.isLoggedIn
  );
  if (to.matched.some(record => record.meta.requiresLogin)) {
    // You can use store variable here to access globalError or commit mutation
    if (store.state.authen.isLoggedIn === false) {
      next("/dang-nhap");
    }
    else {
      console.log(
        "router.beforeEach store.getters.expires",
        store.getters.expires,
        store.getters.isExpire
      );
      if (store.getters.isExpire === true) {
        console.log(
          "Vui lòng đăng nhập ",
          store.state.authen.isLoggedIn,
          store.state.authen.isExpire
        );
        store.dispatch("showModalConfirm"
          , {
            title: "Xác nhận", text: "Bạn đã hết phiên làm việc, vui lòng đăng nhập lại"
          }
        );
      }
      else {
        next();
      }
    }
  }
  else {
    next();
  }
});

// bắt luồng ajax bị lỗi
axios.interceptors.response.use(null, function(err) {
  // HttpStatusCode.Forbidden HttpStatusCode.Unauthorized
  if (err.status === 401 || err.status === 403) {
    localStorage.removeItem("token");
    store.dispatch("logout");
    alert("Không có quyền thao tác");
    return Promise.reject(err);
  }
  alert(err.message);
  console.warn(err);
  return Promise.reject(err);
});

/* eslint-disable no-new */
new Vue({
  el: "#app",
  store,
  router,
  ...layout // Add methods to extend layouts
  // template: '<App/>',
  // components: { App }
});
