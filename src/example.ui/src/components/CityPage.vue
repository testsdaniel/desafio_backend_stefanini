<template>
  <simple-crud
    title="Cities"
    :columns="columns"
    :record="record"
    :list="store.items"
    :errors="store.errors"
    @create="createCity"
    @update="updateCity"
    @delete="deleteCity"
    @reload="getAllCities"
    @reset-form="clearCityErrors"
  >
  <template v-slot:form="{ record }">
    <v-container>
      <v-row>
        <v-col cols="8">
          <v-text-field v-model="record.name" label="City name" :error-messages="store.errors.Name"/>
        </v-col>
        <v-col cols="4">
          <v-text-field v-model="record.uf" label="UF" :error-messages="store.errors.Uf"/>
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
        { text: 'Name', value: 'name' },
        { text: 'UF', value: 'uf' },
        { text: 'Actions', value: 'actions', sortable: false },
      ],
      record: { name: '', uf: '' }
    }),
    created () {
      this.getAllCities()
    },
    computed: {
      ...mapState({ store: state => state.city })
    },
    methods: {
      ...mapActions('city', ['getAllCities', 'createCity', 'updateCity', 'deleteCity', 'clearCityErrors'])
    }
  }
</script>
