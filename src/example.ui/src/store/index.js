import Vuex from 'vuex'
import Vue from 'vue';
import city from './modules/city'
import person from './modules/person'

Vue.use(Vuex);

export default new Vuex.Store({
  modules: { city, person }
})