import {createStore} from 'vuex';
import botList from './botList.json';

export const store = createStore({
    state() {
        return {
            botList: botList,
            userPageId: 0,
            loginId: 102,
            name: '',
            user: {

            },
            isLogin: false,
            bot: {
                "id": 1,
                "name": "Info-Bot",
                "miniDescription": "Привет, роботы! Самые актуальные новинки в мире технологий уже здесь! Специально для вас: абсолютно новые алгоритмы машинного обучения, умные дроны с дальнейшими возможностями.",
                "likes": 10,
                "dislikes": 3,
                "authorName": "Ezekiel",
                "authorId": 100,
                "authorEmail": "ezekiel@mail.ru",
                "date": "03.01.2024",
                "description": "",
                "feedback":[]
            },
            author: {
                id: 0,
                email: 'ezekiel@mail.ru',
                name: 'Ezekiel',
                about: 'Информация о себе.',
            }
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
        editName(state, payload) {
            state.name = payload.value;
        },
        editIsLogin(state, payload) {
            state.isLogin = payload.value;
        },
        editUser(state, payload) {
            state.user = payload.value;
        },
        editBot(state, payload) {
            state.bot = payload.value;
        },
        editAuthor(state, payload) {
            state.author = payload.value;
        },
        addToBotList(state, payload) {
            state.botList.push(payload.value);
        },
    },
});