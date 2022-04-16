<template>
  <simple-crud 
    title="Persons"
    :columns="columns"
    :record="record"
    :list="store.items"
    :errors="store.errors"
    @create="createPerson"
    @update="updatePerson"
    @delete="deletePerson"
    @reload="getAllPersons"
    @reset-form="clearPersonErrors"
  >
  <template v-slot:form="{ record }">
    <v-container>
      <v-row>
        <v-col cols="12">
          <v-text-field v-model="record.name" label="Person name" :error-messages="store.errors.Name"/>
        </v-col>
        <v-col cols="9">
          <v-text-field v-model="record.cpf" label="CPF" :error-messages="store.errors.Cpf"/>
        </v-col>
        <v-col cols="3">
          <v-text-field v-model="record.age" label="Age" type="number" :error-messages="store.errors.Age"/>
        </v-col>
        <v-col cols="12">
          <v-select :items="cities" item-text="name" item-value="id" v-model="record.cityId" label="City" no-data-text="There are no cities registered."/>
        </v-col>
      </v-row>
    </v-container>
  </template>
  </simple-crud>
</template>
<script>
import SimpleCrud from './shared/SimpleCrud.vue'
  import { mapActions, mapState } from 'vuex'
  export default {
    components: { SimpleCrud },
    data: () => ({
      columns: [
        { text: 'Nome', value: 'name' },
        { text: 'CPF', value: 'cpf' },
        { text: 'Idade', value: 'age' },
        { text: 'Cidade', value: 'city' },
        { text: 'Ações', value: 'actions', sortable: false },
      ],
      record: { name: '', cpf: '', age: 0, cityId: 0 }
    }),
    created () {
      this.getAllPersons()
      this.getAllCities()
    },
    computed: {
      ...mapState({ 
        store: state => state.person,
        cities: state => state.city.items
      })
    },
    methods: {
      ...mapActions('city', ['getAllCities']),
      ...mapActions('person', ['getAllPersons', 'createPerson', 'updatePerson', 'deletePerson', 'clearPersonErrors'])
    }
  }
</script>
