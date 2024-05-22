import {createStore} from 'vuex';

export const store = createStore({
    state() {
        return {
            userPageId: 0,
            loginId: 102,
            user: {

            },
            isLogin: false,
            bot: {
                "id": 1,
                "name": "Info-Bot",
                "miniDescription": "Привет, роботы! Самые актуальные новинки в мире технологий уже здесь! Специально для вас: абсолютно новые алгоритмы машинного обучения, умные дроны с дальнейшими возможностями.",
                "countComments": 15,
                "likes": 10,
                "dislikes": 3,
                "authorName": "Ezekiel",
                "authorId": 100,
                "date": "03.01.2024",
                "description": "",
                "feedback":[]
            },
        }
    },
    getters: {},
    mutations: {
        editUserID(state, payload) {
            state.userPageId = payload.value;
        },
        editLogin(state, payload) {
            state.loginId = payload.value;
        },
        editIsLogin(state, payload) {
            state.isLogin = payload.value;
        },
        editUser(state, payload) {
            state.user = payload.value;
        },
        editBot(state, payload) {
            state.bot = payload.value;
        }
    },
});