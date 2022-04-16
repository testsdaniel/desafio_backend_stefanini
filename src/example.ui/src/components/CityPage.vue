<template>
  <simple-crud
    title="Cities"
    :columns="columns"
    :record="record"
    :list="[]"
  >
  <template v-slot:form="{ record }">
    <v-container>
      <v-row>
        <v-col cols="10">
          <v-text-field v-model="record.name" label="City name" />
        </v-col>
        <v-col cols="2">
          <v-text-field v-model="record.uf" label="UF" />
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
        { text: 'Name', value: 'name' },
        { text: 'UF', value: 'uf' },
        { text: 'Actions', value: 'actions', sortable: false },
      ],
      record: { name: '', uf: '' }
    })
  }
</script>
