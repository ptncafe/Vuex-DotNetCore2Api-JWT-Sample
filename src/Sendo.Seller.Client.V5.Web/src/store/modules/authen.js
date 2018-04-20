import apiauthen from "@/api/authen";
import constant from "@/common/constant";

import moment from "moment";

const LOGIN = "LOGIN";
const LOGIN_SUCCESS = "LOGIN_SUCCESS";
const LOGOUT = "LOGOUT";

// initial state
// shape: [{ id, quantity }]
const state = {
  isLoggedIn: !!localStorage.getItem(constant.localStorage_token),
  expires: localStorage.getItem(constant.localStorage_expires)
  // isExpire: null
};

// getters
const getters = {
  isLoggedIn: state => {
    return state.isLoggedIn;
  },
  expires: state => {
    return state.expires;
  },
  isExpire: (state, getters) => {
    console.log("getters isExpire,", state, " >= ", getters);
    if (state.expires == null) {
      return null;
    }
    // nếu thời gian expire lớn hơn hiẹntại và đã login rồi
    console.log("getters ,", moment.utc(getters.expires), " >= ", moment());
    console.log("getters ,", moment(getters.expires) >= moment());

    if (moment.utc(getters.expires) < moment() && getters.isLoggedIn === true) {
      console.log(
        "moment(getters.expires) < moment() && getters.isLoggedIn === true"
      );
      return true;
    }
    return false;
  }
};

// actions
const actions = {
  login({ state, commit, rootState }, creds) {
    console.log("login...", creds);
    commit(LOGIN); // show spinner
    return new Promise(resolve => {
      apiauthen.login(
        creds,
        response => {
          console.log(response);
          localStorage.setItem(
            constant.localStorage_token,
            response.data.token
          );
          localStorage.setItem(
            constant.localStorage_expires,
            response.data.expires
          );
          commit(LOGIN_SUCCESS);
          resolve();
        },
        error => {
          console.log(error);
        }
      );
    });
  },
  logout({ commit }) {
    localStorage.removeItem(constant.localStorage_token);
    localStorage.removeItem(constant.localStorage_expires);
    commit(LOGOUT);
  }
};

// mutations
const mutations = {
  [LOGIN](state) {
    state.pending = true;
  },
  [LOGIN_SUCCESS](state) {
    state.isLoggedIn = true;
    state.pending = false;
  },
  [LOGOUT](state) {
    state.isLoggedIn = false;
  }
};

export default {
  state,
  getters,
  actions,
  mutations
};
