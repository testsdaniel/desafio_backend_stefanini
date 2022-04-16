<template>
  <v-app id="inspire">

    <v-navigation-drawer
      v-model="drawer"
      app
    >
      <v-sheet
        color="grey lighten-4"
        class="pa-4 text-center"
      >
        <v-avatar
          class="mb-4"
          color="grey darken-1"
          size="64"
        ></v-avatar>

        <div>Example UI</div>
      </v-sheet>

      <v-divider></v-divider>

      <v-list>
        <v-list-item
          v-for="[icon, text, link] in links"
          :key="icon"
          link
          :to="link"
        >
          <v-list-item-icon>
            <v-icon>{{ icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>
              {{ text }}
            </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>
<script>
export default {
  name: 'App',

  components: {},

  data: () => ({
    cards: ['Today', 'Yesterday'],
      drawer: null,
      links: [
        ['mdi-home', 'Home', '/'],
        ['mdi-map-marker', 'Cidades', '/city'],
        ['mdi-account', 'Pessoas', '/person']
      ],
  }),
};
</script>
