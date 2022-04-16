import CityApi from '../../services/CityApi'

// initial state
// shape: [{ id, name, uf }]
const state = {
	items: [],
	errors: {}
}

const getters = {}

const actions = {
    getAllCities({ commit }) {
        CityApi.getAll(cities => commit("setCities", cities))
    },
	createCity({ commit }, city) {
		CityApi.create(city, 
			id => commit('addCity', { id, ...city }),
			errors => commit('setErrors', errors))
	},
	updateCity({ commit }, city) {
		CityApi.update(city, 
			() => commit('updateCity', city),
			errors => commit('setErrors', errors))
	},
	deleteCity({ commit }, id) {
		CityApi.delete(id, () => commit('deleteCity', id),
		errors => commit('setErrors', errors))
	},
	clearCityErrors({ commit }) {
		commit('clearErrors')
	}
}

const mutations = {
	setCities(state, cities) {
		state.items = cities
	},
	addCity(state, city) {
		state.items = [ city, ...state.items ]
	},
	updateCity(state, city) {
		state.items = [ city, ...state.items.filter(i => i.id != city.id) ]
	},
	deleteCity(state, id) {
		state.items = [ ...state.items.filter(i => i.id != id) ]
	},
	setErrors(state, errors) {
		state.errors = errors
	},
	clearErrors(state) {
		state.errors = {}
	}
}

export default {
	namespaced: true,
	state,
	getters,
	actions,
	mutations
  }
