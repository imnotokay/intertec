node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube analysis') {
    withSonarQubeEnv('SonarScanner for MSBuild'){
        def scannerHome = tool 'sonarqube-msbuild';
        sh "${scannerHome}/SonarScanner.MSBuild.dll begin /k:rushdigital_z-docker-base-image-updater /o:rushdigital"
        sh 'MSBuild.dll /t:Rebuild'
        sh "${scannerHome}/SonarScanner.MSBuild.dll end"
    }
  }
}