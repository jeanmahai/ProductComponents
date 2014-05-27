"use strict";

module.exports=function(grunt){
	console.info("grunt config");
	//config grunt
	grunt.initConfig({
		pkg:grunt.file.readJSON("package.json")
		// ,concat:{
			// options:{
				// separator:";"
			// }
			// ,dist:{
				// src:["src/*.js"]
				// ,dest:"dist/<%=pkg.name%>.js"
			// }
		// }
		//compression scripts
		// ,uglify:{
			// options:{
				// banner:"banner"
			// }
			// ,dist:{
				// files:{
					// "dist/<%=pkg.name%>.min.js":["<%=concat.dist.dest%>"]
				// }
			// }
		// }
		//js unit
		// ,qunit:{
			// files:["test/*.html"]
		// }
		//js hint
		// ,jshint:{
			// files:["src/*.js","test/*.js"]
			// ,options:{
				
			// }
		// }
		//watch
		// ,watch:{
			// files:["<%=jshint.files%>"]
			// ,tasks:["qunit"]
		// }
		//bower copy
		// ,bowercopy:{
			// options:{
				// clean:true
			// }
			// ,libs:{
				// options:{
					// destPrefix:"libs"
				// }
				// ,files:{
					// "bower_components/qunit/qunit/qunit.js":"qunit.js"
					// ,"bower_components/qunit/qunit/qunit.css":"qunit.css"
				// }
			// }
		// }
		,karma:{
			unit:{
				// options:{
					// files:["Tests/*-karma.js"]
				// },
				// autoWatch:true,
				// // runnerPort:9999,
				// browsers:["Chrome"], 
				// frameworks:["jasmine"]
				configFile:"karma.conf.js"
			}
		}
	});
	
	console.info("load tasks");
	//load grunt plugin
	// grunt.loadNpmTasks("grunt-contrib-uglify");
	// grunt.loadNpmTasks("grunt-contrib-jshint");
	// grunt.loadNpmTasks("grunt-contrib-qunit");
	// grunt.loadNpmTasks("grunt-contrib-watch");
	// grunt.loadNpmTasks("grunt-contrib-concat");
	// grunt.loadNpmTasks("grunt-bowercopy");
	grunt.loadNpmTasks("grunt-karma");
	
	console.info("register task");
	//register test task
	// grunt.registerTask("test",["qunit"]);
	
	//register bowercopy task
	// grunt.registerTask("copyjs",["bowercopy"]);
	
	//register publish task
	// grunt.registerTask("publish",["qunit","concat","uglify"]);
	
	//register default task
	grunt.registerTask("default",["karma"]);
};