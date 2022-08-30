node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube Analysis') {
    def scannerHome = tool 'SonarScanner for MSBuild'
    withSonarQubeEnv() {
      sh "/usr/local/share/dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"imnotokay_intertec_AYLsf3-FBAyuVrc4Q2IV\""
      sh "/usr/local/share/dotnet build"
      sh "/usr/local/share/dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"
    }
  }
}