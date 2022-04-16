import Vuex from 'vuex'
import Vue from 'vue';
import city from './modules/city'

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    city
  }
})