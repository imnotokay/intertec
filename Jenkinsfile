pipeline {
    agent { docker { image 'maven:3.3.3' } }
    options {
		buildDiscarder logRotator(artifactDaysToKeepStr: '', artifactNumToKeepStr: '5', daysToKeepStr: '', numToKeepStr: '5')
		disableConcurrentBuilds()
	}
      stages {
        stage('log version info') {
      steps {
        sh 'mvn --version'
        sh 'mvn clean install'
      }
    }
  }
}