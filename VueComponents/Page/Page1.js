export default {
    data: function () {
        return {
            pageName: 'Page1',
        }  
    },
    methods: {
        init (){
            console.log("Hello Vue !");
        }
    },
    mounted() {
        this.init();
    },
}