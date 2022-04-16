import Vue from 'vue'
import Router from 'vue-router'
import CityPage from '@/components/CityPage'
import HomePage from '@/components/HomePage'
import PersonPage from '@/components/PersonPage'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomePage
    },
    {
      path: '/city',
      name: 'city',
      component: CityPage
    },
    {
      path: '/person',
      name: 'person',
      component: PersonPage
    }
  ]
})