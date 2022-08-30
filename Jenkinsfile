node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube Analysis') {
    def scannerHome = tool 'SonarScanner for MSBuild'
    withSonarQubeEnv() {
      sh "/root/.dotnet/dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"imnotokay_intertec_AYLsf3-FBAyuVrc4Q2IV\""
      sh "/root/.dotnet/dotnet build"
      sh "/root/.dotnet/dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"
    }
  }
}