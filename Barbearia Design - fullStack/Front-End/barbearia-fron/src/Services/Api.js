import axios from  "axios"

export const api = axios.create({
    baseURL:"https://localhost:7189"
})

export const Login = async (Email, Password) => {
    return api.post('User/Login', {Email, Password}).then(result =>{
        return result
    })
    .catch(e => {
        return {code: 400}
    })
}

export const Logout = async (IdUser, Token) => {
    return api.post('User/Logout', {IdUser, Token}).then(result =>{
        return result.status
    })
    .catch(e => {
        return {code:400}
    })
}

export const RegisterUser = async (Name, Email, Password, CPF, Phone) => {
    return api.post('User/RegisterUser', {Name, Email, Password, CPF, Phone}).then(result =>{
        return result.status
    })
    .catch(e =>{
        return {code: 400}
    })
}