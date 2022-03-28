using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjetGsb;


namespace GestionnaireBdd
{
    public class GstBdd
    {
        private MySqlConnection cnx;
        private MySqlCommand cmd;
        private MySqlDataReader dr;
        public GstBdd()
        {
            // La chaine va nous permettre de donner
            // 1) le nom du serveur
            // 2) le nom de la base de données
            // 3) le nom de l'utilisateur
            // 4) le mot de passe
            string chaine = "Server=localhost;Database=projetmedicamentgsb;Uid=root;Pwd=";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }


        public void UpdateMedicament(string nomMedicament, int codeFamille, string compoMedicament, string effetsMedicament, string contreIndicMedicament, double prixChantillon)
        {
            cmd = new MySqlCommand("UPDATE medicament SET MED_NomCommercial '" + nomMedicament + "', FAM_Code ='" + codeFamille + "', MED_Composition = '" + compoMedicament + "', MED_Effets = '" + effetsMedicament + "', MED_Contreindic = '" + contreIndicMedicament + "', MED_PrixChantillon = '" + prixChantillon + "'  WHERE MED_DepotLegal LIKE '" + nomMedicament + "'", cnx);
            cmd.ExecuteNonQuery();
        }


        public List<Medicament> getAllMedicaments()
        {
            List<Medicament> lesMedicaments = new List<Medicament>();


            cmd = new MySqlCommand("SELECT medicament.MED_DepotLegal, medicament.MED_NomCommercial, famille.FAM_Libelle, medicament.MED_PrixChantillon, medicament.MED_Composition, medicament.MED_Contreindic, medicament.MED_Effets, medicament.FAM_Code FROM medicament medicament, Famille famille WHERE medicament.FAM_Code = famille.FAM_Code", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int depot = Convert.ToInt16(dr[0]);
                string nomComm = dr[1].ToString();
                string libelle = dr[2].ToString();
                int prixEchantillon = Convert.ToInt16(dr[3]);
                string compo = dr[4].ToString();
                string contreIndic = dr[5].ToString();
                string effets = dr[6].ToString();
                int famCode = Convert.ToInt16(dr[7]);



                Famille famille = new Famille(famCode, libelle);

                Medicament unMedicament = new Medicament(depot, nomComm, famille, prixEchantillon, compo, contreIndic, effets);
                lesMedicaments.Add(unMedicament);
            }
            dr.Close();
            Console.WriteLine("--------------------------" + lesMedicaments);
            return lesMedicaments;

        }
        public List<TypeIndividu> getAllIndividu()
        {
            List<TypeIndividu> lesIndividus = new List<TypeIndividu>();

            cmd = new MySqlCommand("SELECT TIN_Code, TIN_Libelle FROM type_individu", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TypeIndividu unIndividu = new TypeIndividu(Convert.ToInt32(dr[0]), dr[1].ToString());
                lesIndividus.Add(unIndividu);
            }
            dr.Close();
            return lesIndividus;
        }
        public void UpdateIndividu(int codeTypeIndividu, string libelleTypeIndividu)
        {
            cmd = new MySqlCommand("UPDATE type_individu SET TIN_Libelle = " + "'" + libelleTypeIndividu + "' WHERE TIN_Code = " + codeTypeIndividu, cnx);
            cmd.ExecuteNonQuery();
        }


        public int getLastCodeMedicament()
        {
            int lastId;

            cmd = new MySqlCommand("SELECT Max(MED_DepotLegal) FROM medicament", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            lastId = Convert.ToInt16(dr[0].ToString());
            dr.Close();
            return lastId + 1;
        }

        public void AjouterMedicament(string nomMedoc, int idFamille, string composition, string effet, string contreIndic, double prix)
        {
            
            int lastId = getLastCodeMedicament();
            string temp = prix.ToString().Replace(',', '.');

            cmd = new MySqlCommand("INSERT INTO medicament VALUES (" + lastId + ", '" + nomMedoc + "', '" + idFamille + "', '" + composition + "', '" + effet + "', '" + contreIndic + "', '" + temp + "')", cnx);
            cmd.ExecuteNonQuery();
            dr.Close();
        }

        public int getLastCodeIndividu()
        {
            int lastId;
            cmd = new MySqlCommand("SELECT Max(TIN_CODE) FROM type_individu", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            lastId = Convert.ToInt32(dr[0].ToString());
            dr.Close();
            return lastId + 1;
        }

        public void Ajouterindividu(int TIN_CODE, string libelleTypeIndividu)
        {
            int lastId = getLastCodeIndividu();

            cmd = new MySqlCommand("INSERT INTO type_individu VALUES(" + lastId + ",'" + libelleTypeIndividu + "' )", cnx);
            cmd.ExecuteNonQuery();

            dr.Close();
        }

        public void AjouterPrescription(int depotMedicament, string codeTypeIndividu, string codeDosage)
        {
            cmd = new MySqlCommand("INSERT INTO prescrire (MED_DepotLegal,TIN_Code,DOS_Code) VALUES (" + depotMedicament + "," + codeTypeIndividu + codeDosage + ")", cnx);
            cmd.ExecuteNonQuery();

            dr.Close();
        }

        public Famille getFamilleParNom(string nomFamille)
        {
            Famille laFamille;

            cmd = new MySqlCommand("SELECT FAM_code, FAM_libelle FROM famille WHERE FAM_libelle ='" + nomFamille + "'", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            laFamille = new Famille(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
            dr.Close();
            return laFamille;
        }

        public void AjouterMedicamentPertub(int MedicamentPertubateur, int MedicamentPertub)
        {
            cmd = new MySqlCommand("INSERT INTO  interagir (MED_Perturbateur, MED_MED_Perturbe) VALUES(" + MedicamentPertubateur + "," + MedicamentPertub + ")", cnx);
            cmd.ExecuteNonQuery();
        }

        public List<Medicament> GetMedicamentPertub(int depotLegal)
        {
            List<Medicament> mesMedicamentsPertub = new List<Medicament>();


            cmd = new MySqlCommand("SELECT MED_Perturbateur, MED_NomCommercial, famille.FAM_libelle, MED_Composition, MED_Effets, MED_Contreindic, MED_PrixChantillon, famille.FAM_Code FROM medicament INNER JOIN famille ON famille.FAM_code = medicament.FAM_Code INNER JOIN interagir ON medicament.MED_DepotLegal = interagir.MED_Perturbateur WHERE interagir.MED_MED_Perturbe = " + depotLegal, cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int famCode = 0;
                string famLibelle = dr[2].ToString();                   
                famCode = Convert.ToInt32(dr[7]);
                
                Famille famille = new Famille(famCode, famLibelle);
                Medicament unNouveauMedicamentPertub = new Medicament(Convert.ToInt32(dr[0]), dr[1].ToString(), famille, Convert.ToInt32(dr[6]), dr[3].ToString(), dr[5].ToString(), dr[4].ToString());
                mesMedicamentsPertub.Add(unNouveauMedicamentPertub);
            }
            dr.Close();
            return mesMedicamentsPertub;
        }

        public List<Medicament> GetMedicamentNonPertub(int depotLegal)
        {
            List<Medicament> mesMedicamentsNonPertub = new List<Medicament>();
            int famCode = 0;

            cmd = new MySqlCommand("SELECT MED_DepotLegal, MED_NomCommercial,  famille.FAM_libelle, MED_Composition,  MED_Effets, MED_Contreindic, MED_PrixChantillon, famille.FAM_Code FROM medicament INNER JOIN famille ON famille.FAM_code = medicament.FAM_Code where  MED_DepotLegal not in (SELECT MED_Perturbateur FROM interagir inner join medicament on interagir.MED_MED_Perturbe = medicament.MED_DepotLegal where MED_DepotLegal=" + depotLegal + ")", cnx);
            dr = cmd.ExecuteReader();



            while (dr.Read())
            {
                string famLibelle = dr[2].ToString();
                famCode = Convert.ToInt32(dr[7]);
                
                Famille famille = new Famille(famCode, famLibelle);
                Medicament uneNouveauMedicamentNonPertub = new Medicament(Convert.ToInt32(dr[0]), dr[1].ToString(), famille, Convert.ToInt32(dr[6]), dr[3].ToString(), dr[5].ToString(), dr[4].ToString());
                mesMedicamentsNonPertub.Add(uneNouveauMedicamentNonPertub);
            }
            dr.Close();
            return mesMedicamentsNonPertub;
        }

        public void AjouterPrescription(int codeMedicament, int codeIndividu, int codeDosage, string posologie)
        {
            cmd = new MySqlCommand("INSERT INTO prescrire(MED_DepotLegal, TIN_Code, DOS_Code, PRE_Posologie) VALUES (" + codeMedicament + ", " + codeIndividu + ", " + codeDosage + ", '" + posologie + "')", cnx);
            cmd.ExecuteNonQuery();
        }

        public List<Dosage> getAllDosage()
        {
            List<Dosage> allDosage = new List<Dosage>();

            cmd = new MySqlCommand("SELECT DOS_CODE, DOS_QUANTITE, DOS_UNITE FROM dosage ", cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Dosage unDosage = new Dosage(Convert.ToInt16(dr[0].ToString()), dr[1].ToString(), Convert.ToInt16(dr[2].ToString()));
                allDosage.Add(unDosage);
            }
            dr.Close();
            return allDosage;
        }

        public List<Famille> getAllFamille()
        {
            List<Famille> allFamille = new List<Famille>();
            cmd = new MySqlCommand("SELECT FAM_Code, FAM_Libelle FROM famille", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Famille uneFamille = new Famille(Convert.ToInt32(dr[0]), dr[1].ToString());
                allFamille.Add(uneFamille);
            }
            dr.Close();
            return allFamille;
        }

        public Dictionary<string, int> GetDatasGraph1()
        {
            Dictionary<string, int> lesDatas = new Dictionary<string, int>();

            cmd = new MySqlCommand("SELECT medicament.MED_NomCommercial ,COUNT(interagir.MED_Perturbateur) FROM interagir INNER JOIN medicament on interagir.MED_Perturbateur = medicament.MED_DepotLegal GROUP BY interagir.MED_Perturbateur", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lesDatas.Add(dr[0].ToString(), Convert.ToInt32(dr[1]));
            }
            dr.Close();

            return lesDatas;
        }

        public Dictionary<string, int> GetDatasGraph2()
        {
            Dictionary<string, int> lesDatas = new Dictionary<string, int>();

            cmd = new MySqlCommand("SELECT famille.FAM_Libelle, COUNT(famille.FAM_Libelle)  FROM famille INNER JOIN medicament ON medicament.FAM_Code = famille.FAM_Code GROUP BY medicament.FAM_Code", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lesDatas.Add(dr[0].ToString(), Convert.ToInt16(dr[1]));
            }
            dr.Close();

            return lesDatas;
        }

        public int GetDatasGraph3()
        {
            int somme;

            cmd = new MySqlCommand("SELECT COUNT(medicament.MED_DepotLegal) FROM medicament", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            somme = Convert.ToInt32(dr[0].ToString());
            dr.Close();
            return somme;
        }
    }
}