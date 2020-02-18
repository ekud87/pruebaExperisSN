export default class Utils{

    getDataUser(data){
        return data.map((item)=>{
            return Object.assign({
                id:item.id,
                name:item.name,
                user:item.username,
                email:item.email,
                address:item.address.street+"-"+item.address.suite+"-"+item.address.city+"/  codigo:"
                +item.address.zipcode+"-("+item.address.geo.lat+"/"+item.address.geo.lng+" )",
                phone:item.phone,
                website:item.website,
                company:item.company.name+"-"+item.company.catchPhrase+"-"+item.company.bs
            })
        })[0]
    }


    convertDate(value){
        const date=new Date(value)
        const month=("0"+(date.getMonth()+1)).slice(-2)
        const day=("0"+date.getDate()).slice(-2)
        const hour=("0"+date.getHours()).slice(-2)
        const minutes=("0"+date.getMinutes()+1).slice(-2)
        const format=[date.getFullYear(), month, day].join("-")+ ' '+hour+':'+minutes
        return format;
    }

}