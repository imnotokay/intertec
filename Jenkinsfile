pipeline{
	agent { docker { image 'maven:3.3.3' } }
	options {
		buildDiscarder logRotator(artifactDaysToKeepStr: '', artifactNumToKeepStr: '5', daysToKeepStr: '', numToKeepStr: '5')
		disableConcurrentBuilds()
	}
	stages {
		stage('Hello'){
			steps{
				echo "hello"
			}
		}
	}
}

