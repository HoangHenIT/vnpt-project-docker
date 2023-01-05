import Vue from 'vue'
import Vuex from 'vuex'

// plugin local storage
import VuexPersistence from 'vuex-persist'
import logger from '@/plugins/logger'

import { user } from './user'
// import { admin } from './admin'

Vue.use(Vuex)

const vuexPersist = new VuexPersistence({
    key: 'website',
    // modules: ['user', 'admin']
    modules: ['user']
})
const debug = process.env.NODE_ENV !== 'production' 

export const store = new Vuex.Store({
    modules: {
        user,
        // admin
    },
    strict: debug,
    plugins: debug ? [logger(), vuexPersist.plugin] : [vuexPersist.plugin],
    state: {
        header: {
        title: '',
        list: []
        }
    },
    mutations: {
        setHeader (state, header) {
          state.header = header
        }
    },
    actions: {
        setHeader (context, header) {
            context.commit('setHeader', header)
        }
    }
})