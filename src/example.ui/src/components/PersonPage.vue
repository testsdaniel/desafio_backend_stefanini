<template>
  <simple-crud 
    title="Persons"
    :columns="columns"
    :record="record"
    :list="[]"
  >
  <template v-slot:form="{ record }">
    <v-container>
      <v-row>
        <v-col cols="12">
          <v-text-field v-model="record.name" label="Person name" />
        </v-col>
        <v-col cols="9">
          <v-text-field v-model="record.cpf" label="CPF" />
        </v-col>
        <v-col cols="3">
          <v-text-field v-model="record.age" label="Age" type="number"/>
        </v-col>
        <v-col cols="12">
          <v-select :items="[]" item-text="name" item-value="id" v-model="record.cityId" label="City" no-data-text="There are no cities registered."/>
        </v-col>
      </v-row>
    </v-container>
  </template>
  </simple-crud>
</template>
<script>
import SimpleCrud from './shared/SimpleCrud.vue'
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
    })
  }
</script>
