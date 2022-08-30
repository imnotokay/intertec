node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube Analysis') {
    def scannerHome = tool 'SonarScanner for MSBuild'
    withSonarQubeEnv() {
      sh "export PATH=${PATH}:${HOME}/.dotnet/tools"
      sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"imnotokay_intertec_AYLsf3-FBAyuVrc4Q2IV\""
      sh "dotnet build"
      sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"
    }
  }
}