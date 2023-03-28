<template>
    <!-- <section>
      <div class="page-content">
        <div class="image-home"></div>
      </div>
    </section> -->
    <body id="pcont-content" style="padding:0px 12px 12px 12px;overflow: hidden">
		<div id="pcont">
			<div id="pcont-content">
					<div class="container-fluid">
							<div class="row">
									<h2 style="width:100%;font-weight: bold;text-align: center;color: #fcd538;margin-top: 0;">DASHBOARD CHẤT LƯỢNG MẠNG - DỊCH VỤ</h2>
							</div>
							<div class="clearfix"></div>
							<div class="row" style="margin-top: 1em">
									<div class="circle-container">
											<!--<![endif]-->
													<a href="#" class="center" target="_blank"><img src="../../assets/center02.png"></a>
													<a href="#" class="list-item" target="_blank" style="transform: rotate(0deg) translate(0px, -200px) rotate(0deg);"><img src="../../assets/default.png"></a>
													<h5 class="tttitle" style="top: 24%;left: 31%;text-align:center;transform: rotate(0deg) translate(0px, -200px) rotate(0deg);">Test 1</h5>
													<a href="#" class="list-item" target="_blank" style="transform: rotate(32.7273deg) translate(0px, -200px) rotate(-32.7273deg);"><img src="../../assets/default.png"></a>
													<h5 class="tttitle" style="top: 38%;left: 62%;text-align:left; transform: rotate(40deg) translate(0px, -200px) rotate(-40deg);">Test 2</h5>
													<a href="#" class="list-item" target="_blank" style="transform: rotate(65.4545deg) translate(0px, -200px) rotate(-65.4545deg);"><img src="../../assets/default.png"></a>
													<h5 class="tttitle" style="top: 30%;left: 63%;text-align:left; transform: rotate(80deg) translate(0px, -200px) rotate(-80deg);">Test 3</h5>
													<a href="#" class="list-item" target="_blank" style="transform: rotate(98.1818deg) translate(0px, -200px) rotate(-98.1818deg);"><img src="../../assets/default.png"></a>
													<h5 class="tttitle" style="top: 25%;left: 73%;text-align:left; transform: rotate(120deg) translate(0px, -200px) rotate(-120deg);">Test 4</h5>
													<a href="#" class="list-item" target="_blank" style="transform: rotate(130.909deg) translate(0px, -200px) rotate(-130.909deg);"><img src="../../assets/default.png"></a>
													<h5 class="tttitle" style="top: 121%;left: 101%;text-align:left;transform: rotate(0deg) translate(0px, -200px) rotate(0deg);">Test 5</h5>
													<a href="#" class="list-item" target="_blank" style="transform: rotate(163.636deg) translate(0px, -200px) rotate(-163.636deg);"><img src="../../assets/default.png"></a>
													<h5 class="tttitle" style="top: 128%;left: 49%;text-align:left; transform: rotate(40deg) translate(0px, -200px) rotate(-40deg);">Test 6</h5>
													<a href="#" class="list-item" target="_blank" style="transform: rotate(196.364deg) translate(0px, -200px) rotate(-196.364deg);"><img src="../../assets/default.png"></a>
													<h5 class="tttitle" style="top: 102%;left: -64%;text-align:right; transform: rotate(80deg) translate(0px, -200px) rotate(-80deg);">Test 7</h5>
													<a href="#" class="list-item" target="_blank" style="transform: rotate(229.091deg) translate(0px, -200px) rotate(-229.091deg);"><img src="../../assets/default.png"></a>
													<h5 class="tttitle" style="top: 49%;left: -80%;text-align:right; transform: rotate(120deg) translate(0px, -200px) rotate(-120deg);">Test 8</h5>
													<a href="#" class="list-item" target="_blank" style="transform: rotate(261.818deg) translate(0px, -200px) rotate(-261.818deg);"><img src="../../assets/default.png"></a>
													<h5 class="tttitle" style="top: 95%;left: -51%;text-align:right;transform: rotate(0deg) translate(0px, -200px) rotate(0deg);">Test 9</h5>
													<a href="#" class="list-item" target="_blank" style="transform: rotate(294.545deg) translate(0px, -200px) rotate(-294.545deg);"><img src="../../assets/default.png"></a>
													<h5 class="tttitle" style="top: 59%;left: -77%;text-align:right; transform: rotate(40deg) translate(0px, -200px) rotate(-40deg);">Test 10</h5>
													<a href="#" class="list-item" target="_blank" style="transform: rotate(327.273deg) translate(0px, -200px) rotate(-327.273deg);"><img src="../../assets/default.png"></a>
													<h5 class="tttitle" style="top: 37%;left: -59%;text-align:right; transform: rotate(40deg) translate(0px, -200px) rotate(-40deg);">Test 11</h5>													
									</div>
							</div>
					</div>
			</div>
	</div>
	</body>
    
  
</template>

<script>
export default {
    name:"Home",
    data(){
      return{

      }
    },
    mounted(){
        if(this.$auth.getClientInfoFromStorage()){
          // this.$root.context.logOut()
        }
    },
    methods:{

    }
}
</script>

<style scoped>
 #pcont {
    top: 0;
}

#pcont-content {
    background: #1f1e30 url('../../assets/bg_qoeqos.png') no-repeat center bottom;
    background-size: cover;
    position: relative;
    height: 887px;
    padding-top:20px;
}

.circle-container {
    position: relative;
    width: 430px;
    height: 430px;
    margin: 200px auto 40px;
}

    .circle-container a {
        display: block;
        overflow: hidden;
        position: absolute;
        top: 50%;
        left: 50%;
        width: 93px;
        height: 93px;
        margin: -50px;
    }

        .circle-container a.center {
            width: 200px;
            height: 200px;
            margin-top: -100px;
            margin-left: -100px;
        }

        .circle-container a.list-item {
            background: rgb(2,0,36);
            background: linear-gradient(180deg, #4447c8 0%, rgb(54, 62, 192) 50%, #2d2271 100%);
            box-shadow: 0px 2px 5px #2958cc;
            border-radius: 50%;
            padding: 20px;
            top: 50%;
            left: 50%;
            z-index: 1;
        }

    .circle-container img {
        display: block;
        width: 100%;
    }

    /* this is for showing the circle on which the images are placed */
    .circle-container:after {
        position: absolute;
        top: 22px;
        left: 22px;
        width: 385px;
        height: 385px;
        border: solid 2px #267dff;
        border-radius: 50%;
        pointer-events: none;
        content: '';
    }

.tttitle {
    position: absolute;
    font-weight: bold;
    width: 165px;
    line-height: 1.7;
	color: white;
}

@media only screen and (max-height: 900px){
   .circle-container {
    position: relative;
    width: 430px;
    height: 430px;
    margin: 80px auto 40px;
	  margin-top:100px;
  }
}
</style>