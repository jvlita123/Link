import App from '../App'
import Login from '../components/Login'
import PageNotFound from '../components/PageNotFound'
import Register from '../components/Register'

export const routes = [
    {
        path: '/',
        component: <App />
    },
    {
        path: '/login',
        component: <Login />
    },
    {
        path: '/signup',
        component: <Register />
    },
    {
        path: '*',
        component: <PageNotFound />
    },
]