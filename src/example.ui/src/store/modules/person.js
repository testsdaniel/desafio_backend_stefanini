import PersonApi from '../../services/PersonApi'

// initial state
// shape: [{ id, name, cpf, cityId, age }]
const state = {
	items: [],
	errors: {}
}

const getters = {}

const actions = {
    getAllPersons({ commit }) {
        PersonApi.getAll(persons => commit("setPersons", persons))
    },
	createPerson({ commit }, person) {
		PersonApi.create(person, 
			id => commit('addPerson', { id, ...person }),
			errors => commit('setErrors', errors))
	},
	updatePerson({ commit }, person) {
		PersonApi.update(person, 
			() => commit('updatePerson', person),
			errors => commit('setErrors', errors))
	},
	deletePerson({ commit }, id) {
		PersonApi.delete(id, () => commit('deletePerson', id))
	},
	clearPersonErrors({ commit }) {
		commit('clearErrors')
	}
}

const mutations = {
	setPersons(state, persons) {
		state.items = persons
	},
	addPerson(state, person) {
		state.items = [ person, ...state.items ]
	},
	updatePerson(state, person) {
		state.items = [ person, ...state.items.filter(i => i.id != person.id) ]
	},
	deletePerson(state, id) {
		state.items = [ ...state.items.filter(i => i.id != id) ]
	},
	setErrors(state, errors) {
		state.errors = errors
	},
	clearErrors(state) {
		state.errors = []
	}
}

export default {
	namespaced: true,
	state,
	getters,
	actions,
	mutations
  }
