node {
  stage('SCM') {
    checkout scm
  }
  stage('SonarQube Analysis') {
    def scannerHome = tool 'SonarScanner for MSBuild'
    withSonarQubeEnv() {
      sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll begin /k:\"imnotokay_intertec_AYLsf3-FBAyuVrc4Q2IV\""
      sh "dotnet build /var/jenkins_home/workspace/Intertec/IntertecCounterChallenge/IntertecCounterChallenge.csproj"
      sh "dotnet ${scannerHome}/SonarScanner.MSBuild.dll end"
    }
  }
}

