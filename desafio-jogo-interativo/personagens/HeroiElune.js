const PersonagemAmigo = require('./PersonagemAmigo');

class HeroiElune extends PersonagemAmigo {
    constructor(nome, vida, dano, defesa) {
        super(vida, dano, defesa);
        this.nome = nome;
    }
    
    atacar() {
        return Math.floor(Math.random() * this.dano);
    }
    defender(dano) {
        this.vida -= dano - this.defesa;
    }
}

module.exports = HeroiElune;