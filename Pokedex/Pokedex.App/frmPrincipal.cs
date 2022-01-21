using Pokedex.App.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pokedex.App.Entities;

namespace Pokedex.App
{
    public partial class frmPrincipal : Form
    {
        private readonly PokemonDataAccess _dataAccess;
        private int _id = 1;
        private int _total;
        private Pokemon _pokemon;
        private List<Pokemon> _pokemons;

        public frmPrincipal()
        {
            InitializeComponent();
            _dataAccess = new PokemonDataAccess();
        }

        private async void frmPrincipal_Load(object sender, EventArgs e)
        {
            btnAnterior.Enabled = false;
            _pokemons = await _dataAccess.ObterTodos();
            
            _pokemon = await ObterPorId(_id);

            _total = await ObterTotalPokemons();

            SetInfoPokemon(_pokemon);
        }

        #region BotoesAcoes

        private async void btnProximo_Click(object sender, EventArgs e)
        {
            _id++;
            _total = await ObterTotalPokemons();

            if (_id > 1) btnAnterior.Enabled = true;

            if (_total == _id) btnProximo.Enabled = false;

            _pokemon = await ObterPorId(_id);

            SetInfoPokemon(_pokemon);
        }

        private async void btnAnterior_Click(object sender, EventArgs e)
        {
            _id--;
            _total = await ObterTotalPokemons();

            if (_id == 1) btnAnterior.Enabled = false;

            if (_total > _id) btnProximo.Enabled = true;

            _pokemon = await ObterPorId(_id);

            SetInfoPokemon(_pokemon);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            var stringBusca = txtBusca.Text;

            var result = await ObterPorCodigo(stringBusca);

            if (result == null)
            {
                result = await ObterPorNome(stringBusca);
                if (result != null)
                {
                    SetInfoPokemon(result);
                }
                else
                {
                    try
                    {
                        int id = Convert.ToInt32(stringBusca);
                        result = await ObterPorId(id);
                        SetInfoPokemon(result);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Pokemon não encontrado, refaça sua busca.", "Sem resultado", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                SetInfoPokemon(result);
            }
        }

        #endregion

        #region SetValores

        public async void SetInfoPokemon(Pokemon pokemon)
        {
            pictureBoxPokemon.ImageLocation = pokemon.Img;
            lblName.Text = pokemon.Name;
            var types = string.Empty;
            foreach (var type in pokemon.Type)
            {
                if (types == String.Empty)
                    types = types + type;
                else
                    types = types + " - " + type;
            }
            lblType.Text = types;
            lblHeight.Text = pokemon.Height;
            lblWeight.Text = pokemon.Weight;
            _id = pokemon.Id;

            if (_total == _id)
                btnProximo.Enabled = false;
            else
                btnProximo.Enabled = true;

            if (_id == 1)
                btnAnterior.Enabled = false;
            else
                btnAnterior.Enabled = true;
        }

        #endregion

        #region MétodosDeBusca

        public async Task<Pokemon> ObterPorId(int codigo)
        {

            return _pokemons.FirstOrDefault(pokemon => pokemon.Id == codigo);
        }

        public async Task<Pokemon> ObterPorCodigo(string codigo)
        {
            return _pokemons.FirstOrDefault(pokemon => pokemon.Num == codigo);
        }

        public async Task<Pokemon> ObterPorNome(string nome)
        {
            return _pokemons.FirstOrDefault(pokemon => pokemon.Name == nome);
        }

        public async Task<int> ObterTotalPokemons()
        {
            return _pokemons.Count;
        }

        #endregion
    }
}
