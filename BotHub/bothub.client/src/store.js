import {createStore} from 'vuex';

export const store = createStore({
    state() {
        return {
            userPageId: 0,
            loginId: 102,
            user: {

            }
        }
    },
    getters: {},
    mutations: {
        editUser(state, payload) {
            state.userPageId = payload.value;
        },
        editLogin(state, payload) {
            state.loginId = payload.value;
        }
    },
});