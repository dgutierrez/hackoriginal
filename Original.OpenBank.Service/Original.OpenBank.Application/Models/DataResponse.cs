﻿using System; using System.Collections.Generic; using Newtonsoft.Json;  namespace Original.OpenBank.Application.Models {     public class DataResponse     {         public DataResponse()         {         }          public int qtd_trans_mes         {             get;             set;         }          public int tempo_casa         {             get;             set;         }          public int tendencia_saldo         {             get;             set;         }          public int tendencia_investimento         {             get;             set;         }          public bool investidor         {             get;             set;         }          public int encerrou_conta         {             get;             set;         }          public int idade         {             get;             set;         }     }      public class MLRequest     {         [JsonProperty("Inputs")]         public Inputs Inputs         {             get;             set;         }          [JsonProperty("GlobalParameters")]         public GlobalParameters GlobalParameters         {             get;             set;         }          public MLRequest()         {             this.Inputs = new Inputs();             this.GlobalParameters = new GlobalParameters();         }     }      public class Inputs     {         public Input1 input1         {             get;             set;         }          public Inputs()         {             this.input1 = new Input1();         }     }      public class Input1     {         [JsonProperty("ColumnNames")]         public List<string> ColumnNames         {             get;             set;         }          [JsonProperty("Values")]         public List<List<string>> Values         {             get;             set;         }          public Input1()         {             this.ColumnNames = new List<string>();             this.Values = new List<List<string>>();         }     }      public class GlobalParameters { }        public class Value     {         public List<string> ColumnNames { get; set; }         public List<string> ColumnTypes { get; set; }         public List<List<string>> Values { get; set; }     }      public class Output1     {         public string type { get; set; }         public Value value { get; set; }     }      public class Results     {         public Output1 output1 { get; set; }     }      public class MLResponse     {         public Results Results { get; set; }     }  }  