const SHOW = "SHOW";
const HIDE = "HIDE";

// initial state
const state = {
  isShow: false,
  data: {
    title: "",
    text: ""
  }
};

// getters
const getters = {
  isShow: state => {
    return state.isShow;
  }
};

// actions
const actions = {
  showModalConfirm({ commit, state }, data) {
    commit(SHOW, data);
  },
  hideModalConfirm({ commit, state }, data) {
    commit(HIDE, data);
  }
};

// mutations
const mutations = {
  [SHOW](state, data) {
    state.isShow = true;
    state.data = data;
  },
  [HIDE](state, data) {
    state.isShow = false;
    state.data = {
      title: "",
      text: ""
    };
  }
};

export default {
  state,
  getters,
  actions,
  mutations
};
