<template>
  <v-data-table
    :headers="headers"
    :items="data"
    sort-by="name"
    class="elevation-1"
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>{{title}}</v-toolbar-title>
        <v-divider class="mx-4" inset vertical />
        <v-spacer></v-spacer>
        <v-dialog v-model="dialog" max-width="550px">
          <template v-slot:activator="{ on, attrs }">
            <v-btn
              color="primary"
              dark
              class="mb-2"
              v-bind="attrs"
            >
              <v-icon>mdi-refresh</v-icon>
            </v-btn>
            <v-btn
              color="primary"
              dark
              class="mb-2 mx-2"
              v-bind="attrs"
              v-on="on"
            >
              <v-icon>mdi-plus</v-icon>
            </v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="text-h5">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <slot name="form" :record="editedItem"></slot>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="close" >
                Cancel
              </v-btn>
              <v-btn color="blue darken-1" text @click="save" >
                Save
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
        <v-dialog v-model="dialogDelete" max-width="550px">
          <v-card>
            <v-card-title class="text-h5">Are you sure you want to delete this record?</v-card-title>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
              <v-btn color="blue darken-1" text @click="deleteItemConfirm">Ok</v-btn>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:[`item.actions`]="{ item }">
      <v-icon small class="mr-2" @click="editItem(item)" >
        mdi-pencil
      </v-icon>
      <v-icon small @click="deleteItem(item)" >
        mdi-delete
      </v-icon>
    </template>
    <template v-slot:no-data>
      There is no data to display.
    </template>
  </v-data-table>
</template>
<script>
  export default {
    props: {
      title: { type: String, required: true },
      columns: { type: Array, required: true },
      list: { type: Array, required: true },
      record: { type: Object, required: true }
    },
    data: () => ({
      dialog: false,
      dialogDelete: false,
      headers: [],
      data: [],
      editedIndex: -1,
      editedItem: {},
      defaultItem: {},
    }),

    computed: {
      formTitle () {
        return this.editedIndex === -1 ? 'Add' : 'Edit'
      },
    },

    watch: {
      dialog (val) {
        val || this.close()
      },
      dialogDelete (val) {
        val || this.closeDelete()
      },
    },

    created () {
      this.initialize()
    },

    methods: {
      initialize () {
        this.data = Object.assign([], this.list)
        this.headers = Object.assign([], this.columns)
        this.editedItem = Object.assign({}, this.record)
        this.defaultItem = Object.assign({}, this.record)
      },

      editItem (item) {
        this.editedIndex = this.data.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialog = true
      },

      deleteItem (item) {
        this.editedIndex = this.data.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm () {
        this.data.splice(this.editedIndex, 1)
        this.closeDelete()
      },

      close () {
        this.dialog = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      closeDelete () {
        this.dialogDelete = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      save () {
        if (this.editedIndex > -1) {
          Object.assign(this.data[this.editedIndex], this.editedItem)
        } else {
          this.data.push(this.editedItem)
        }
        this.close()
      },
    },
  }
</script>
