import Vue from "vue";
import Vuex from "vuex";

//
import cart from "./modules/cart";
import products from "./modules/products";
import authen from "./modules/authen";
import commonModalConfirm from "./modules/common/modal-confirm";
// import createLogger from '../../../src/plugins/logger'

Vue.use(Vuex);

const debug = process.env.NODE_ENV !== "production";

export default new Vuex.Store({
  modules: {
    cart,
    products,
    authen,
    commonModalConfirm
  },
  strict: debug
  // plugins: debug ? [createLogger()] : []
});
