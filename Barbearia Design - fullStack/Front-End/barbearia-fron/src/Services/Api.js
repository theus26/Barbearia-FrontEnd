import axios from  "axios"
const token = localStorage.getItem("Token");
console.log(token)
export const api = axios.create({
    baseURL:"https://localhost:7189",
    headers:{
        Authorization:`Bearer ${token}`
    }
})

export const GetSession = async () =>{
    return api.get('User/ValidateSession').then(result => {
        return result.status
    })

    .catch(e => {
        return {code: 401}
    })
}

export const GetHoraries = async () =>{
    return api.get('User/GetAllHoraries').then(result => {
        return result
    })

    .catch(e => {
        return {code: 400}
    })
}

export const GetServices = async () =>{
    return api.get('User/GetAllServices').then(result =>{
        return result
    })

    .catch(e =>{
        return {code: 400}
    })
}

export const GetShavyes = async () => {
    return api.get('User/GetAllShavys').then( result =>{
        return result
    })

    .catch(e =>{
        return {code: 400}
    })
}

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

export const RegisterScheduling = async (IdUser, HairCurtDate, DesiredService, Time, barberEnum) =>{
    return api.post('User/Scheduling', {IdUser, HairCurtDate, DesiredService, Time, barberEnum}).then(result =>{
        return result
    })
    .catch (e =>{
        return {code: 400, CodeUnauthorized: 401}   
    })
}

export const GetAllPerId = async (IdUser) =>{
    return api.get('User/GetSchedulingPerIdUser/' + IdUser).then(result =>{
        return result
    })
    .catch((err) => {
        return {code: 401} 
     });
}

export const GetAll = async () =>{
    return api.get('User/GetAllScheduling').then(result =>{
        return result;
    })
    .catch(e => {
        return {code: 401}
    })
}

export const CompleteScheduling = async (IdScheduling, SchedulingCompleted) =>{
    return api.post('User/SchedulingCompleted', {IdScheduling, SchedulingCompleted}).then(result =>{
        return result.status;
    })
    .catch (e=> {
        return {code: 400}
    })
}

export const DeleteScheduling = async (IdScheduling) =>{
    return api.delete('User/DeleteScheduling/' + IdScheduling).then(result =>{
        return result.status
    })

    .catch(e =>{
        return {code: 400}
    })
}

export const UpdateScheduling = async (IdUser, IdScheduling, HairCurtDate, DesiredService, Time, barberEnum) =>{
    return api.put('User/UpdateScheduling', {IdUser, IdScheduling, HairCurtDate, DesiredService, Time, barberEnum}).then(result =>{
        return result.status
    })
    .catch (e => {
        return {code:400}
    })
}
 export const UpdateUser = async (IdUser,Name, Email, Password, CPF, Phone,) =>{
    return api.put('User/UpdateUser', {IdUser, Name, Email, Password, CPF, Phone }).then(result =>{
        return result
    })
    .catch (e =>{
        return {code: 400, CodeUnauthorized: 401}   
    })
 }

 export const GetAllBarber = async (Name) =>{
    return api.get('User/GetBarberAppointment/' + Name).then(result =>{
        return result
    })
    .catch (e =>{
        return {code: 400, CodeUnauthorized: 401}   
    })
 }

 export const GetUserId = async (IdUser) =>{
    return api.get('User/GetUserId/' + IdUser).then(result =>{
        return result
    })
    .catch (e =>{
        return {code: 400, CodeUnauthorized: 401}   
    })
 }